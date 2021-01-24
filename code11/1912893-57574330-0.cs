    public List<string> GetNewValues()
    {
        string material, size, color;
        List<string> newValues = new List<string>();
        for (int i = 0; i < dataGridView1.Rows.Count; i++)
        {
            material = dataGridView1.Rows[i].Cells["Material"].Value.ToString();
            size = dataGridView1.Rows[i].Cells["Size"].Value.ToString();
            color = dataGridView1.Rows[i].Cells["Color"].Value.ToString();
            newValues.Add($"{ material }+{ size }+{ color }");
        }
        return newValues;
    }
