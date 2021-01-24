public class Asset()
{
   [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
   [Key]
   public Guid Id { get; set; }
   public Guid MainImageId{ get; set; }
   public Image MainImage { get; set; }
   public ICollection<Image> Images { get; set; }
}
public class Image()
{
   [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
   [Key]
   public Guid Id { get; set; }
   public Guid AssetId { get; set; }
   public Asset Asset { get; set; }
   
   //THIS WAS ADDED TO SOLVE THE PROBLEM:
   public ICollection<Asset> MainAssets {get;set;}
}
I added the collection `MainAssets` to the Images class and then updated my model to include the following two mappings:
modelBuilder.Entity<Image>()
    .HasOne(x => x.Asset)
    .WithMany(x => x.Images)
    .HasForeignKey(x => x.AssetId);
modelBuilder.Entity<Asset>()
    .HasOne(x => x.MainImage)
    .WithMany(x => x.MainAssets)
    .HasForeignKey(x => x.MainImageId);
And now everything works fine again. It seems that by adding the collection of `MainAssets` was key to having Entity framework understand the relationship better. 
