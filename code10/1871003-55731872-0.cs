    private void uploadButton_Click(object sender, RoutedEventArgs e)
    {
    	OpenFileDialog openFileDialog = new OpenFileDialog();
    
    	if(openFileDialog.ShowDialog() == true)
    	{
    		string filepath = openFileDialog.FileName;
    		string filename = openFileDialog.SafeFileName;
    
    		string local_path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    		string parent_path = local_path + @"\ProjectName";
    		string child_path = parent_path + @"\user";
    
    		if(!System.IO.Directory.Exists(parent_path))
    		{
    			System.IO.Directory.CreateDirectory(parent_path);
    		}
    
    		if(!System.IO.Directory.Exists(child_path))
    		{
    			System.IO.Directory.CreateDirectory(child_path);
    		}
    
    		string target_path = child_path + @"\" + filename;
    		File.Copy(filepath, target_path);
    		photoBox.Source = new BitmapImage(new Uri(target_path));
    		staff.photo_path = target_path;
    	}
    }
