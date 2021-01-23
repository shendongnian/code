      private void FormLoad(object sender, EventArgs e)
      {
         radioCsv.Tag = DataTargetTypes.CsvFile;
         radioTabbed.Tag = DataTargetTypes.TxtFile;
         radioSas.Tag = DataTargetTypes.SasFile;
      }
      private void RadioButtonCheckedChanged(object sender, EventArgs e)
      {
         var radio = (RadioButton) sender;
         this.DataDestinationType = (DataTargetTypes)radio.Tag;
      }
