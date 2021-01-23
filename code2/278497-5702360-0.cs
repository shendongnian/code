    	public void GetFileList(ref List<FileInfo> fList, string fPath, BackgroundWorker scanner)
        {
            DirectoryInfo di = new DirectoryInfo(fPath);
            FileInfo[] fi = di.GetFiles();
			
			List<string> progressData = new List<string>();
            
			foreach (FileInfo fiTemp in fi)
            {
                //ar ~$ saakas nevajadzigie temp faili, tos izlaižam
                if (fiTemp.Name.StartsWith("~$") == false)
                {
                    fList.Add(fiTemp);
					progressData.Add(fiTemp.Name);
					if (progressData.Count > 50){
						scanner.ReportProgress(0, progressData.ToArray());
						progressData.Clear();//You've just copied the data to an array and sent it to the GUI, clear the list and start counting up again
					}
                }
            }
			
			if (progressData.Count > 0){
				scanner.ReportProgress(0, progressData.ToArray());
			}
			
            DirectoryInfo[] dFolders = di.GetDirectories();
            //katrai apakšmapei rekursivi izsaucam šo funkciju
            foreach (DirectoryInfo d in dFolders)
            {
                GetFileList(ref fList, d.FullName, scanner);
            }
        }
