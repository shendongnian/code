c#
class Item
{
  [Column("Length")]  
  public decimal _Length {
    get => (decimal)Length;
    set => Length = (double)value;
  }
  [NotMapped]
  public double Length { get; set; }
}
