cshtml
@foreach(var property in typeof(Foo).GetProperties()) {
    <p>
        <div class="row" >
            <div class="col-md-3">
                @Html.Label(@property.Name)
            </div>
            <div class="col-md-3">
                @Html.Editor(@property.Name,  new { htmlAttributes = new{ @class="form-control" } })
                @Html.ValidationMessage(@property.Name, new { htmlAttributes = new { @class="text-danger"} })
            </div>
        </div>
    </p>
}
## Demo :
I create a custom Foo DTO as below :
    public class Foo{
        public int Id {get;set;}
        public string Name {get;set;}
        public string Address {get;set;}
        public DateTime UpdatedAt{get;set;}
    }
And the rendered form is :
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/BeoJf.png
