c#
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using eMessage.Classes;
using Tulpep.NotificationWindow;
using MySql.Data.MySqlClient;
namespace eMessage.Forms
{
    public partial class EMessageForm : MetroFramework.Forms.MetroForm
    {
        private int? _lastId;
        private const string MessageQuery = "SELECT * FROM eMessage ORDER BY id DESC LIMIT 1";
        private const string DataFilePath = "somefilename.ext";
/*
        private static string _eMessage1;
*/
        public EMessageForm()
        {
            InitializeComponent();
        }
        private void EMessageForm_Load(object sender, System.EventArgs e)
        {
            _lastId = ReadLastSeenId();
            var timer = new System.Timers.Timer
            {
                Interval = 100,
                SynchronizingObject = this,
            };
            timer.Elapsed += delegate
            {
                ReadInformationFromeMessage();
            };
            timer.Start();
        }
        private void ReadInformationFromeMessage()
        {
            try
            {
                var myCommand = new MySqlCommand(MessageQuery, ConexaoBancoMySql.GetConexao());
                var reader = myCommand.ExecuteReader();
                if (!reader.Read()) return;
                var currentId = reader.GetInt32("id");
                if (currentId == _lastId) return;
                _lastId = currentId;
                var eMessage = (reader.GetString("eMessage"));
                var pop = new PopupNotifier
                {
                    //escopo de mensagem
                    TitleText = "*  lastInfo  *",
                    ContentText = "" + eMessage,
                    //fim do escopo de mensagem
                    TitleFont = new Font("Tahoma", 12),
                    //cor do titulo do form
                    TitleColor = Color.White,
                    BodyColor = Color.FromArgb(0, 75, 0),
                    //contorno do form
                    BorderColor = Color.FromArgb(0, 255, 0),
                    //cor da fonte do aviso
                    ContentColor = Color.FromArgb(255, 255, 255),
                    //tamanho da fonte
                    ContentFont = new Font("Tahoma", 12F),
                    //cor da fonte do aviso quando mouse em cima
                    ContentHoverColor = Color.FromArgb(255, 255, 255),
                    //centralizacao da mensagem no form 
                    ImagePadding = new Padding(0),
                    ContentPadding = new Padding(10),
                    Delay = 15000,
                    GradientPower = 150,
                    //tamanho da borda superior
                    HeaderHeight = 1,
                    Scroll = true,
                    ShowCloseButton = true,
                    ShowGrip = true,
                    ShowOptionsButton = false,
                };
                pop.Popup();
                WriteLastSeenId(_lastId);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                ConexaoBancoMySql.FecharConexao();
            }
        }
        private static void WriteLastSeenId(int? id)
        {
            var rawValue = (id != null ? id.Value.ToString() : string.Empty);
            File.WriteAllText(DataFilePath, rawValue);
        }
        private static int? ReadLastSeenId()
        {
            int? id = null;
            if (!File.Exists(DataFilePath)) return null;
            var rawValue = File.ReadAllText(DataFilePath);
            if (int.TryParse(rawValue, out var temp))
            {
                id = temp;
            }
            return id;
        }
    }
}
