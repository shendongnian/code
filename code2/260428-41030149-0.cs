    //using statements
    using System;
    using System.ComponentModel.DataAnnotations;  //needed for Display annotation
    using System.ComponentModel;  //needed for DisplayName annotation
    public class Whatever
    {
        //Property
        [Display(Name ="Release Date")]
        public DateTime ReleaseDate { get; set; }
    }
    //cshtml file
    @Html.DisplayNameFor(model => model.ReleaseDate)
