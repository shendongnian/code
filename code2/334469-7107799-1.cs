    private void warning1ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (colorDialog1.ShowDialog() == DialogResult.OK)
        {
            StyleSettings.Warn1Color = colorDialog1.Color;
            tbWarn1Hrs.BackColor = StyleSettings.Warn1Color;
            tbWarn1Mins.BackColor = StyleSettings.Warn1Color;
            tbWarn1Secs.BackColor = StyleSettings.Warn1Color;
            tbWarn1Msg.BackColor = StyleSettings.Warn1Color;
        }
    }
