csharp
public List<DocumentLines> Items;
public decimal OrderTotal
{
  get
  {
    return Items.Sum(item => item.LinePrice);
  }
}
