     private void button1_Click(object sender, EventArgs e)
        {
            //all the directories
            string[] path = {"C:\\Test", "C:\\TestABC", "C:\\Test1\\123", "C:\\Test2\\145"}; 
            for(int i = 0; i < path.Length; i++)
            {
               if(!Directory.Exists(path[i])
                     Directory.CreateDirectory(path[i]);
            }
        }
