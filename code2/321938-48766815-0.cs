     private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            //If the row is not the ative row, you would see that color instead.
            e.Layout.Override.FilterCellAppearance.BackColor = Color.Green;
            //This would be visible when the row has filters applies, and not being active at the same time.
            e.Layout.Override.FilterCellAppearanceActive.BackColor = Color.GreenYellow;
            //The appearance that would be applied after you filtered IN some of the rows based on your filters.
            e.Layout.Override.FilteredInCellAppearance.BackColor = Color.BlueViolet;
            //After a filter is applied, and FilteredInCellAppearance is not being set.
            e.Layout.Override.FilteredInRowAppearance.BackColor = Color.Pink;
            //If FilterCellAppearance is not being set, the one below would take effect.
            e.Layout.Override.FilterRowAppearance.BackColor = Color.Plum;
            //The formatting of the filter rows, that have active filters already.
            e.Layout.Override.FilterRowAppearanceActive.BackColor = Color.PowderBlue;
        }
