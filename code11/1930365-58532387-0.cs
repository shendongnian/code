    using System;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Threading.Tasks;
    namespace LogisticsNote.Utils
    {
    public class ManageCombo
    {
        private static Brush OPAQUE_BACKGROUND_ON_OPEN = Brushes.WhiteSmoke;
        public static void SetBackgroundManagementEvents(params ComboBox[] combo)
        {
            foreach (ComboBox c in combo) SetBackgroundManagementEvents(c);
        }
        public static void SetBackgroundManagementEvents(ComboBox combo)
        {
            combo.DropDownOpened += Combo_DropDownOpened;
            combo.DropDownClosed += (s, e) =>
                (s as ComboBox).Background = Brushes.Transparent;
        }
        private static void Combo_DropDownOpened(object sender, EventArgs e)
        {
            var combo = sender as ComboBox;
            combo.IsDropDownOpen = false;
            if (combo.Items.Count == 0)
            {
                combo.Background = Brushes.Transparent;
                return;
            }
            combo.DropDownOpened -= Combo_DropDownOpened;
            combo.Background = OPAQUE_BACKGROUND_ON_OPEN;
            Task.Delay(100).ContinueWith(_ =>
            {
                combo.Dispatcher.Invoke((Action)(() =>
                {
                    combo.IsDropDownOpen = true;
                    combo.DropDownOpened += Combo_DropDownOpened;
                }));
            });
        }
    }
    }
