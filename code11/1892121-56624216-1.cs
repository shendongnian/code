c#
public static void Main(string[] args){
      DirectoryInfo d = new DirectoryInfo(@"D:\Test");//Assuming Test is your Folder
      FileInfo[] Files = d.GetFiles("*.txt"); //Getting Text files
      int tempCount = 0;
      string tempFolderName = "TestFolder";
      int tempCountFolder = 0;
      for (int i = 0; i < Files.Length; i++)
      {
        if (tempCount <= 50){
          Files[i].MoveTo($@"{tempFolderName}{tempCountFolder}");
        } else {
          tempCount = 0;
          tempCountFolder += 1;
        }
    }
}
