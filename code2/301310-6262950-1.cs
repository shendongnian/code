            int index = listBox1.IndexFromPoint(e.X, e.Y);
            var s = listBox1.Items[index]; //Putting item instead of
            DragDropEffects dde1 = DoDragDrop(s, DragDropEffects.All);
            if (dde1 == DragDropEffects.All)
            {
                listBox1.Items.RemoveAt(listBox1.IndexFromPoint(e.X, e.Y));
            }
        }
