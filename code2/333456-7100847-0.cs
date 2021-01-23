        private void gridView1_ColumnPositionChanged(object sender, EventArgs e)
        {
            if ((colMail1Check.VisibleIndex - colMail1.VisibleIndex) != 1)
            {
                colMail1Check.VisibleIndex = colMail1.VisibleIndex + 1;
            }
            if ((colMail2Check.VisibleIndex - colMail2.VisibleIndex) != 1)
            {
                colMail2Check.VisibleIndex = colMail2.VisibleIndex + 1;
            }
        }
