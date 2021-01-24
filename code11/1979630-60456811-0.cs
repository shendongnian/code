c#
public class ObjectBase {
  private int money;
  public int Money {
    get
    {
        return money;
    }
    set
    {
        money = value;
        UpdateMoneyText();
    }
  }
}
public class YourClass : ObjectBase {
  public void SomeMethod(int newMoney) {
    this.Money = newMoney; // setter used here, because this.money is inaccessible
  }
}
