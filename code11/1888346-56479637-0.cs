	(int itt = 1; itt < listView1.Items.Count; itt++)
	{
		int Totall =
			int.Parse(listView1.Items[itt].SubItems[2].Text) +
			int.Parse(listView1.Items[itt].SubItems[3].Text) +
			int.Parse(listView1.Items[itt].SubItems[4].Text);
		
		//Сумма чисел добавить во всего 
		listView1.Items[itt].SubItems["Total"].Text = Totall.ToString();
	}
