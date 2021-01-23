    private void CargarTipoGasto(ref DataGridViewComboBoxCell ComboColumn)
    {
       ComboColumn.Value = string.Empty;
       ComboColumn.DataSource = from oPro in dtContext.tblProducto
                                where oPro.ProductoId == objProducto.ProductoId
                                from oMat in dtContext.tblMatrizDeCuentasGD
                                where oMat.Partida.Substring(0,3) ==
                                  oPro.tblObjetoGasto.ObjetoGastoId.Substring(0,3)
                                from oTipGas in dtContext.tblTipoGasto
                                where oMat.TipoGasto == oTipGas.TipoGastoId
                                select oTipGas;
    
       ComboColumn.ValueMember = TIPOGASTO_ID;
       ComboColumn.DisplayMember = TIPOGASTO_VALOR;
    }
