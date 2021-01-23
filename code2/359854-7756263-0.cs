    public void fillAttachment(List<string> attachList)
    {
        string result = "";
        //OR (if you want to append to existing textbox data)
        //string result = txtAttach.Text;
 
        for (int i = 0; i < attachList.Count; i++)
        {
            Console.WriteLine("List: " + attachList[i]);
            result += attachList[i] + ";";
        }
        txtAttach.Text = result;
    }
