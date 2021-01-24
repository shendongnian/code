      public abstract class Character
    	{
		public virtual void OnTriggerEnter2D(Collider2D other)
		{
			DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
			ProcessHit(damageDealer);
		};
		public void ProcessHit(DamageDealer damageDealer)
		{
			//ProcessHit accessible for all classes that inherit Character
			health -= damageDealer.GetDamage();
			if (health <= 0)
			{
				Destroy(gameObject);
			}
		}
	}
	public class Enemy : Character
	{
		//this has both methods as declared in Character
	}
	public class Player : Character
	{
		// this needs to be overriden for Player
		public override void OnTriggerEnter2D(Collider2D other)
		{
			//Enter OnTriggerEnter2D logic for Player
		}
	}
