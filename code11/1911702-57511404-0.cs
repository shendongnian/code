// Assume Status is a class that inherits MonoBehaviour and sets up a timer and bool
//  to show that your status is able to damage the attached gameobject
public class PoisonStatus : Status
{
    // Do your setup for damage value
    [...]
    // Affect your player
    void Update()
    {
        // canDamageGameObject is a bool based on timer and current time in Status
        if (canDamageGameObject)
            affectedGameObjectDamageComponent.Damage(damageValue)
    }
}
