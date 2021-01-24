    using System;
    using System.Windows;
    using System.Windows.Forms;
    
    namespace copy_file
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
                    dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    dlg.Filter = ".sav Files (*.sav)|*.sav|All files (*.*)|*.*";
                    DialogResult result = dlg.ShowDialog();
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        txtSourceFile.Text = dlg.FileName;
                    }
                }
                catch (Exception ex) { }
            }
                     
            private void Button_Click1(object sender, RoutedEventArgs e)
            {
                try
                {
                    FolderBrowserDialog dlg = new FolderBrowserDialog();
                    dlg.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);             
                    DialogResult result = dlg.ShowDialog();
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        txtCopyPath.Text = dlg.SelectedPath;
                    }
                }
                catch (Exception ex) { }           
            }
    
            private void Button_Click2(object sender, RoutedEventArgs e)
            {
                try
            {
                if(txtCopyPath.Text.Length>1 && txtSourceFile.Text.Length > 1)
                {                    
                    string fName = System.IO.Path.GetFileName(txtSourceFile.Text);
                    System.IO.File.Copy(txtSourceFile.Text, txtCopyPath.Text +"\\"+ fName, true);
                    success = true;
                }
                System.Windows.MessageBox.Show("Info", success.ToString());
                success = false;
            }
                catch (Exception ex) { }
            }
        }
    }
