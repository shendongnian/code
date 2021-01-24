     private void LockChecked_Click(object sender, EventArgs e) {
       List<Control> agenda = new List<Control>() {this};
       while (agenda.Count > 0) {
         List<Control> nextAgenda = new List<Control>();        
         foreach (Control control in agenda) {
           foreach (Control child in control.Controls)
             nextAgenda.Add(child);
           if (control is CheckBox cb && cb.Checked) 
             cb.Enabled = false;
         }
         agenda = nextAgenda;  
       } 
     }
