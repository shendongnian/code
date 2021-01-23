    //change this line
    DataRow daRow = dataRecipe.Tables["CookBookRecipes"].NewRow();
    daRow[0] = tbRName.Text;
    daRow[1] = listBox1.SelectedItem.ToString();
    daRow[2] = tbRCreate.Text;
    daRow[3] = tbRIngredient.Text;
    daRow[4] = tbRPrep.Text;
    daRow[5] = tbRCook.Text;
    daRow[6] = tbRDirections.Text;
    daRow[7] = tbRYield.Text;
    daRow[8] = textBox1.Text;
    if (MessageBox.Show("You wish to save your updates?", "Save Updates?", MessageBoxButtons.OKCancel) == DialogResult.OK)
    {
    //add & change this too
    dataRecipe.Tables["CookBookRecipes"].Rows.Add(daRow);
        dataAdapt.Update(dataRecipe, "CookBookRecipes");
        MessageBox.Show("Recipe Updated", "Update");
    }
}
    
   
