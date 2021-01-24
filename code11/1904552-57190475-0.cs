    private void checkBox_CheckedChanged(object sender, EventArgs e)
            {
                CheckBox checkbox = sender as CheckBox;
                if (checkbox == null) return;
                if (checkbox.Checked)
                {
                    CheckAdicionarMaterial(checkbox.Text);//The text of the boxes is always the string I want to pass here.
                }
                else
                {
                   if (Confirmacao("Desmarcar removerá todas ocorrências do material. Continuar?"))
                        CheckRemoverMaterial(checkbox.Text);
                    else
                        checkbox.Checked = true;
                }
            }
