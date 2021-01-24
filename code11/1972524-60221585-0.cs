    string color="";
    for (int i = 0; i < Colors.Items.Count; i++)
            {
                if (Colors.Items[i].Selected == true)
                {
                    color += Colors.Items[i].Text + ",";
                }
            }
            color = color.TrimEnd(',');
            pd1.text=color; 
 
