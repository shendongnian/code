     @(Html.Kendo().AutoComplete()
          .Name("productAutoComplete") //The name of the AutoComplete is mandatory. It specifies the "id" attribute of the widget.
          .DataTextField("input") //Specify which property of the Product to be used by the AutoComplete.
          .DataSource(source =>
           {
              source.Read(read =>
              {
                   read.Action("GetAutocomplete", "yourControler"); //Set the Action and Controller names.
              })
              .ServerFiltering(true); //If true, the DataSource will not filter the data on the client.
           })
        )
