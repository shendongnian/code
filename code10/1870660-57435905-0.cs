     public string SwitchStatusPagto
        {
          get
          {
            if (!string.IsNullOrEmpty(StatusPagto))
            {
              switch (StatusPagto)
              {
                case "A":
                case "D":
                case "R":
                  return "Ativo";
                case "E":
                case "X":
                  return "Cancelado";
                case "M":
                  return "Reembolsado";
                default:
                  return StatusPagto;
              }
            }
            return string.Empty;
          }
        }
    <td>@Html.DisplayFor(fr => itemRequisicao.SwitchStatusPagto)</td>
