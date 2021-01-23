    <td>
       <% int counter = 0; %>
       <% IEnumerable<IEnumerable<DAL.Models.TransactionEntity>> tranlist = 
              (IEnumerable<IEnumerable<DAL.Models.TransactionEntity>>)ViewData.Model; %>
       <% foreach (DAL.Models.TransactionEntity te in tranlist.ElementAt(0))
          {.... create rows/columns as needed for the data in a HTML sub-table ......} %>
     </td>
     <td>
        <% counter = 0; %>
        <% foreach (DAL.Models.TransactionEntity te in tranlist.ElementAt(1))
          {..........} %>
     </td>
     <td>
        <% counter = 0; %>
        <% foreach (DAL.Models.TransactionEntity te in tranlist.ElementAt(2))
          {..........} %>
     </td>
