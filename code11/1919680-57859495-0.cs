// MainWindow.xaml
<Window x:Class="DownloadFileAsync.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="MainWindow" Height="350" Width="525">
    <StackPanel>
      <TextBlock>Uri:</TextBlock>
      <TextBox x:Name="UriTxt"></TextBox>
      <TextBlock>File Name:</TextBlock>
      <TextBox x:Name="FileNameTxt"></TextBox>
      <Label x:Name="StatusLbl">Waiting...</Label>
      <Button x:Name="DownloadBtn" Click="DownloadBtn_Click">Download</Button>
    </StackPanel>
</Window>
lang-csharp
// MainWindow.xaml.cs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace DownloadFileAsync
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         InitializeComponent();
         _client = new System.Net.WebClient();
         _client.DownloadFileCompleted += _client_DownloadFileCompleted;
         // I was using https://github.com/danielmiessler/SecLists/raw/master/Passwords/bt4-password.txt as the file I was testing which
         // required TLS1.2. This line enables TLS1.2, you may or may not need it.
         ServicePointManager.SecurityProtocol = (SecurityProtocolType)0x00000C00;
      }
      void _client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
      {
         if (e.Error != null)
         {
            // If there was an error downloading the file, show it.
            MessageBox.Show(e.Error.Message);
         }
         else if (e.Cancelled)
         {
            StatusLbl.Content = "Cancelled!";
         }
         else
         {
            // There weren't any errors and the download wasn't cancelled, so then it must have completed successfully.
            // If the file is an archive, this is where you could extract it. Do be aware that you're back on the UI thread
            // at this point, so the UI will block while the file is extracting.
            //
            // If extraction is going to take some time and you don't want it to block, you'll either need to use an async
            // API to extract the archive or start a BackgroundWorker here to extract the archive.
            StatusLbl.Content = "File Downloaded!";
         }
         DownloadBtn.IsEnabled = true;
      }
      private void DownloadBtn_Click(object sender, RoutedEventArgs e)
      {
         if (string.IsNullOrEmpty(FileNameTxt.Text))
         {
            MessageBox.Show("You must enter a file name");
            return;
         }
         Uri uri;
         if (!Uri.TryCreate(UriTxt.Text, UriKind.Absolute, out uri))
         {
            MessageBox.Show("You must enter a valid uri");
            return;
         }
         StatusLbl.Content = "Downloading...";
         DownloadBtn.IsEnabled = false;
         _client.DownloadFileAsync(uri, FileNameTxt.Text);
      }
      private readonly System.Net.WebClient _client;
   }
}
I made a note of it in the comments, but the delegate you provide to `DownloadFileCompleted` is executing on the UI thread. So, if you need to extract an archive there the UI will block until the extraction is complete. You'll either need to use an asynchronous API for extracting the archive, or start a `BackgroundWorker` to extract the archive if you need to avoid blocking the UI during the extraction.
