    private void button1_Click(object sender, EventArgs e)
    {
        nilaiHuruf1.Text = nilaiHuruf(Convert.ToInt32(tugas1.Text), Convert.ToInt32(uts1.Text), Convert.ToInt32(uas1.Text));
    }
    public string nilaiHuruf(int a, int b, int c)
    {
        string rtn = "";
        Nilai vnilai = new Nilai();
        int hasil = vnilai.Calculate(a, b, c);
        if (hasil >= 85)
        {
            rtn = "A";
        }
        else if (hasil >= 80)
        {
            rtn = "A-";
        }
        else if (hasil >= 75)
        {
            rtn = "B+";
        }
        else if (hasil >= 70)
        {
            rtn = "B";
        }
        else if (hasil >= 65)
        {
            rtn = "B-";
        }
        else if (hasil >= 60)
        {
            rtn = "C+";
        }
        else if (hasil >= 55)
        {
            rtn = "C";
        }
        else if (hasil >= 45)
        {
            rtn = "D";
        }
        else
        {
            rtn = "E";
        }
        return rtn;
    }
	
