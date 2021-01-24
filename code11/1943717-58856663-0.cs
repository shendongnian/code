c#
String fileNameb = string.Format("{0}//userdata.dat", Application.StartupPath);
string fileName = string.Format("{0}//userdata.dat", Application.StartupPath);
I think your problem here.
Before close program you write 
App.Users.WriteXml(string.Format("{0}//userdata.dat", Application.StartupPath));
and
App.Barcode.WriteXml(string.Format("{0}//userdata.dat", Application.StartupPath));
it will overwrite your destination file I think.
You can use two different destination file.
c#
private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataGridView1.DataSource = usersBindingSource;
            dataGridView2.DataSource = barcodeBindingSource;            
            usersBindingSource.EndEdit();
            App.Users.AcceptChanges();
            barcodeBindingSource.EndEdit();
            App.Barcode.AcceptChanges();         
            App.Users.WriteXml(string.Format("{0}//userdata.dat", Application.StartupPath));
            App.Barcode.WriteXml(string.Format("{0}//userdata.dat", Application.StartupPath));
        }
