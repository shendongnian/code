    public partial class SCon : UserControl
        {
            public SCon()
            {
                InitializeComponent();
                if (Persoanas == null)
                {
                    Persoanas = new List<Persoana>();
                }
            }
    
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            public List<Persoan> Persoanas { get; set; }
    
        }
    
        [Serializable]
        public class Persoan   
        {
            public int Id { get; set; }
            public String Name { get; set; }
        }
