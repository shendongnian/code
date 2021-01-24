     private void LockChecked_Click(object sender, EventArgs e) {
       Queue<Control> agenda = new Queue<Control>(new [] { this });
       while (agenda.Count > 0) {
         Control control = agenda.Dequeue();
         if (control is CheckBox cb && cb.Checked)
           cb.Enabled = false;
         foreach (Control child in control.Controls)
           agenda.Enqueue(child);
       }
     }
