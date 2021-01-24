csharp
public class Item
{
    public int Id { get; set; }
}
More specific types of items will then inherit from the `Item` class, like perhaps a weapon.
> I want a way to easily manage and modify items and their values, even if they are customized (e.g. when an Item does 20 base dmg and it was modified by the player to do +10 dmg, when I change the base dmg to 30, the players item should do 40 dmg in total)
Your weapon class might have a base damage value, a damage modifier value, and a calculated total damage value based on the previous two:
csharp
public class Weapon : Item
{
    public int BaseDamage { get; set; }
    public int DamageModifier { get; set; }
    public int TotalDamage => BaseDamage + DamageModifier;
}
> An Item needs to have some kind of slots for things like stickers or attachments, which are also items itself.
You could create an interface here (or even move this into your base class - I don't know enough about the system you're designing to make that call) which will contain a collection of `Item` objects for this purpose:
csharp
public interface IAttachmentContainer
{
    IEnumerable<Item> Attachments { get; set }
}
Then implement this interface on any item that can have attachments.
As for persistence, you will want to look into some type of database system (like Traendy mentioned in the comments).
----------
I hope this is enough to get you started. Please let me know if you have any questions.
