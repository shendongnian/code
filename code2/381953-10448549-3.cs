        private void ParamComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                Param selected = cb.SelectedItem as Param;
                if (selected != null)
                {
                    Debug.WriteLine("Selection Changed: Selected " + selected.Name);
                }
                StringBuilder str = new StringBuilder();
                foreach (var obj in cb.Items)
                {
                    Param p = obj as Param;
                    str.Append("Name:" + p.Name + " IsSelected:" + p.IsSelected + Environment.NewLine);
                    Debug.WriteLine(str);
                }
                MessageBox.Show(str.ToString());
            }
