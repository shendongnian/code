    @section scripts{
      <script>
          var isNew = @Html.Raw(Json.Encode(Model.isNew));
          function Initizalize()
          {
              if (!isNew)
              {
                  DoSomeStuff();
              }   
          }
          function DoSomeStuff() {
            
          }
          Initizalize();
      </script>
    }
