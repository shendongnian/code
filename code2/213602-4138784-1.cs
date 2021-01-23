string s1 = TextBox1.Text;
string s2 = TextBox2.Text;
string s3 = TextBox3.Text;
string s4 = maskedtextbox1.Text;
using (StreamWriter sw = new StreamWriter("C:\\text.txt", true))  // True to append data to the file; false to overwrite the file
{
	sw.WriteLine(string.Format("[0],[1],[2],[3]", new object[] { s1, s2, s3, s4 }));
}
