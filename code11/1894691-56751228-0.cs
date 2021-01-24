    <ul>
      @foreach(var comment in Model.DetailsViewModel.Comments)
      {
       <li>comment.DateComment</li>
       <li>comment.Comment</li>
      }
    <ul>
