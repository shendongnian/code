    private void cmbobx_version_SelectedIndexChanged(object sender, EventArgs e)
    {
        Type t = this.GetType(); //need to get the type
        MethodInfo method = t.GetMethod("Getinfo_" + cmbobx_version.Text.Replace('.', '_'));   //put together function name
         method.Invoke(this, new object[] {Fridge, "Order" }); //call function with parameters
    }
