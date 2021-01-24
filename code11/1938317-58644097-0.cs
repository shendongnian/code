var input = port.ReadExisting();
int message;
if (int.TryParse(input, out message))
{
	btnLab.Text = Convert.ToString(message);
	if (message == 1)
	{
		MessageBox.Show("Er is drugsafval gedropt in Breda! Klik op alarm voor de locatie en op route voor de weg ernaartoe.");
		logBox.Items.Add("Merodelaan Breda," + DateTime.Now);
	}
	else if (message == 2)
	{
		MessageBox.Show("Er is drugsafval gedropt in Tilburg! Klik op alarm voor de locatie en op route voor de weg ernaartoe.");
		logBox.Items.Add("Leijweg Tilburg," + DateTime.Now);
	}
	else if (message == 3)
	{
		MessageBox.Show("Er is drugsafval gedropt in Breda! Klik op alarm voor de locatie en op route voor de weg ernaartoe.");
		logBox.Items.Add("Bergsche Hoevenpad Oss," + DateTime.Now);
	}
	else if (message == 0)
	{
		MessageBox.Show("Er is momenteel geen alarm.");
	}
}
