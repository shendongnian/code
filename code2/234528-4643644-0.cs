        ...    
        foodsDa.Fill(ds, "Food_table");
        //add extra column structures to dataset
        ds.Tables["Food_table"].Columns.Add(new DataColumn("ColFoodQtyStock", System.Type.GetType("System.Int32")));
        ds.Tables["Food_table"].Columns.Add(new DataColumn("ColFoodStatus", System.Type.GetType("System.String")));
        //loop through all the rows and add the data to the new columns dynamically
        for (int i = 0; i < ds.Tables["Food_table"].Rows.Count; i++)
        {
            ds.Tables["Food_table"].Rows[i]["ColFoodQtyStock"] = 0;
            ds.Tables["Food_table"].Rows[i]["ColFoodStatus"] = "Always On Stock";
        }
        dataGridView1.DataSource = ds;
        dataGridView1.DataMember = "Food_table";
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dataGridViewCellStyle1.Font = new Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        dataGridView1.Columns[0].Width = 420;
        dataGridView1.Columns[1].Width = 180;
        dataGridView1.Columns[2].Width = 300;
        dataGridView1.Columns[3].Width = 308;
    }
    catch (Exception ex)
    ...
