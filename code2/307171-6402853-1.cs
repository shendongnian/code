        List<int> g = new List<int>();
        List<int> h = new List<int>();
        int text1, text2, text3, text4;
        int.TryParse(textBox1.Text, out text1);
        int.TryParse(textBox2.Text, out text2);
        int.TryParse(textBox3.Text, out text3);
        int.TryParse(textBox4.Text, out text4);
        g.Add(text1 * 60 + text2);
        h.Add(text3 * 60 + text4);
