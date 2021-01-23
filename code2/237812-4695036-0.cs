        bool hoverSeen = false;
        private void ovalShape1_MouseHover(object sender, EventArgs e) {
            if (!hoverSeen) {
                hoverSeen = true;
                // Todo, fix position
                Point pos = ovalShape1.Parent.PointToClient(Cursor.Position);
                toolTip1.Show("On oval", ovalShape1.Parent, pos);
            }
        }
        private void ovalShape1_MouseLeave(object sender, EventArgs e) {
            if (hoverSeen) toolTip1.Hide(ovalShape1.Parent);
            hoverSeen = false;
        }
