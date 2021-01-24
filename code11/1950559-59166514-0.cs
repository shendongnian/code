    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            float dmg = chscript.DamageDealt();
            chscripta.HP = chscript.HP - dmg;
            if (chscripta.HP <= 0)
            {
               Destroy(_villain);
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Character chscript1 = _villain.GetComponent<Character>();
            float dmg1 = chscript1.DamageDealt();
            Character chscript1a = _hero.GetComponent<Character>();
            chscript1a.HP -= dmg1;
            if(chscript1a.HP <= 0)
            {
                Destroy(_villain);
            }
        }
    }
Rather than finding the game object during runtime, you could consider creating a reference and configuring the hero/villain references by dragging the gameobject to the inspector after making this change to your code. You can do this for both Components and GameObjects, so with the following code you should have 4 "slots" in your inspector:
public class FightControl : MonoBehaviour
{
    public GameObject _hero;
    public GameObject _villain;
    public Character chscript;
    public Character chscripta;
//... the rest of your code (the Update() method above)
