[Parameter]
public EventCallback<int> DeleteCallback { get; set; }
You could then do:
<EntityActionMenu  DeleteCallback="@Delete"></EntityActionMenu>
@code {
   protected void Delete(int id)
   {
       if (id == 0) return;
       
       /* your code */ 
   }
}
