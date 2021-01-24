private async void Button_Click(object sender, RoutedEventArgs e)
{
    string targetFolder = PathSrc.Text;
    var dir=new DirectoryInfo(targetFolder);
    var size=await Task.Run(()=> 
            dir.EnumerateFiles("*",SearchOption.AllDirectories)
               .Sum(fi=>fi.Length));
    MessageBox.Show ("The size is " + size / 1000000 + " MB.");
}
