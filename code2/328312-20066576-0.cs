        private void btndlt_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[0];
            string id = row.Cells[0].Value.ToString();
            string path = @"";
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode node = doc.SelectSingleNode("/TheToDoList/item[todoID='" + id + "']");
            node.ParentNode.RemoveChild(node);
            doc.Save(path);
            MessageBox.Show("Selected Record Deleted Successfully");
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[0];
            int id1 = Convert.ToInt32(row.Cells[0].Value);
            string path = @"";
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode node = doc.SelectSingleNode("/TheToDoList/item[todoID='" + id1 + "']");
            node.ParentNode.RemoveChild(node);
            doc.Save(path);
                    //    //Load the XML File
                        doc.Load(path);
                        
                        XmlElement root = doc.CreateElement("TheToDoList");
                        XmlElement Subroot = doc.CreateElement("item");
                        XmlElement todoID = doc.CreateElement("todoID");
                        XmlElement todoDate = doc.CreateElement("todoDate");
                        XmlElement todoTime = doc.CreateElement("todoTime");
                        XmlElement todoItem = doc.CreateElement("todoItem");
                        XmlElement todoStatus = doc.CreateElement("todoStatus");
                        XmlElement UserID = doc.CreateElement("UserID");
                        //Add the values for each nodes
                        todoID.InnerText = row.Cells[0].ToString();
                        todoDate.InnerText = row.Cells[1].ToString();
                        todoTime.InnerText = row.Cells[2].ToString();
                        todoItem.InnerText = row.Cells[3].ToString();
                        todoStatus.InnerText = row.Cells[4].ToString();
                        UserID.InnerText = row.Cells[5].ToString();
                        //Construct the document
                        doc.AppendChild(root);
                        root.AppendChild(Subroot);
                        Subroot.AppendChild(todoID);
                        Subroot.AppendChild(todoDate);
                        Subroot.AppendChild(todoTime);
                        Subroot.AppendChild(todoItem);
                        Subroot.AppendChild(todoStatus);
                        Subroot.AppendChild(UserID);
                        doc.Save(path);
                        MessageBox.Show("Selected Record Edited Successfully");
