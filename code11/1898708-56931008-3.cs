    <div class="c-box_item">
         @foreach(var item in Model.CategoryList)
         {
              <ul >
                 <li>
                 <span><a href="#"> @item.Name</a></span>
                 <div>
                     @foreach(var subitem in item.Children)
                      {
                        <ul>
                           <li>
                           <span><a href="#"> @subitem.Name</a></span>
                           <div>
                              @if (subitem.Children.Count > 0)
                              {
                                  @foreach (var subitems in subitem.Children)
                                  {}
                              }
                            </div>
                            </li>
                          </ul>                                        
                   }
                 </div>
                </li>
           </ul>
        }
    </div>
