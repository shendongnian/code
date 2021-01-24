    public class GenRec
    {
        public List<string> items = new List<string>();
    }
    
    public GenRec GetRec(string Line)
    {
        GenRec rec = new GenRec();
    
        try
        {
            string[] fields = Line.Split(new char[1] { '\t' });
    
            for (int i = 0; i < fields.Length; i++)
                rec.items.Add(fields[i]);
        }
        catch (Exception ex)
        {
            System.Windows.Forms.MessageBox.Show("Bad import data on line: " + Line + "\n" + ex.Message, "Error",
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Error);
        }
    
        return rec;
    }
    
    public List<GenRec> Import()
    {
        List<GenRec> loadedData = new List<GenRec>();
        using (StreamReader sr = File.OpenText(fileName))
        {
            string Line = null;
    
            while ((Line = sr.ReadLine()) != null)
                loadedData.Add(GetRec(Line));
        }
    
        return loadedData;
    }
