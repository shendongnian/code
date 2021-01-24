csharp
@Html.ActionLink(
   "Upvote",// linkText
   "Upvote",// actionName
   "ItemRating", // controllerName
   new {// routeValues
          id = item.ItemId // this will have to reflect your actual parameter
       },
   null  // htmlAttributes
)
Another thing (and I suspect this is the issue) is the properties on your `ItemRating` model (or lack thereof to be precise):
if you check out your database scripts (`DataProviders/.../00.00.01.SqlDataProvider`) you will see `ItemRatingId` as a PK for your `Memeometer_Item_Ratings` table:
sql
CREATE TABLE {databaseOwner}{objectQualifier}Memeometer_Item_Ratings
    (
    ItemRatingId int NOT NULL IDENTITY (1, 1),
	ItemIdFk int NOT NULL,
	PcIdentity nvarchar(MAX) NOT NULL,
	ItemRatingPoints int NOT NULL
    )  ON [PRIMARY]
     TEXTIMAGE_ON [PRIMARY]
GO
while in your object you've got correct decorators, the class itself didn't have the property:
csharp
    [TableName("Memeometer_Item_Ratings")]
    [PrimaryKey("ItemRatingId", AutoIncrement = true)] // decoration looks good
    [Cacheable("ItemRatings", CacheItemPriority.Default, 20)]
    [Scope("ModuleId")]
    public class ItemRating
    {
        public int ItemId { get; set; } = -1; // you have this, 
        public int ItemRatingId { get; set; } = -1; // while it likely needs to be this
        .......your other properties....
    }
hopefully that fixes the issue for you
