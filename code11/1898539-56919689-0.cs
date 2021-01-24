    //Allows you to perform file IO:
    using System.IO;
    using System.Windows;
    
    namespace TryStuff2019 {
        public partial class MainWindow : Window {
            public MainWindow() {
                InitializeComponent();
            }
    
            private void BtnSaveToFile_Click(object sender, RoutedEventArgs e) {
                var saveThisToFile = "This is some sample text to save";
                var fileName = "MyOutput.txt";
    
                //This will save some text to a file in the same folder as your project exe file
                using(StreamWriter sw = File.CreateText(fileName)) {
                    sw.Write(saveThisToFile);
                }
            }
    
            private void BtnReadFromFile_Click(object sender, RoutedEventArgs e) {
                var inputFileName = "MyOutput.txt";
                string fileContents;
                using(StreamReader sr = File.OpenText(inputFileName)) {
                    fileContents = sr.ReadToEnd();
                }
    
                txtData.Text = fileContents;
            }
        }
    }
