    private void BtnAdd_Click(object sender, RoutedEventArgs e)
    {
        var pu = new ProductUnit();
        pu.UnitNicname = TxtUnitNicName.Text;
        pu.UnitFaName = TxtUnitName.Text;
        StructureMapDefenation.Container.GetInstance<IUnitService>().Add(pu);
    }
