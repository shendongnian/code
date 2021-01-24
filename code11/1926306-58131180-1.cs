       public partial  class Sis2D
       {
        public Sis2D()  //  you need to add this code
        {
        }
        public void LlenaListBox()
        {
            Excel.Worksheet wsFL = Globals.ThisWorkbook.Worksheets["FileList"];
            ListaFiles.Items.Add(wsFL.Range["A2"].Value);
            ListaFiles.Items.Add(wsFL.Range["A3"].Value);
        }
        }
