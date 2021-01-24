	public class MonsterMove : MonoBehaviour
	{
		...
		
		protected enum State
		{
			Idle,
			StartPatrolling,
			Patrolling,
			StopPatrolling,
		}
		protected State state = State.StartPatrolling;
		...
		void FixedUpdate()
		{
			switch (state)
			{
				case State.StartPatrolling:
					{
						StartCoroutine(PatrolTime());
						state = State.Patrolling;
						break;
					}
				case State.StopPatrolling:
					{
						StartCoroutine(IdleTime());
						state = State.Idle;
						break;
					}
				case State.Patrolling:
					{
						Move();
						break;
					}
				case State.Idle:
					{
						// nothing to be done
						break;
					}
			}
		}
		
		...
		
		IEnumerator PatrolTime()
		{
			yield return new WaitForSeconds(Random.Range(MinPatrolTime, MaxPatrolTime));
			state = State.StopPatrolling;
		}
		
		IEnumerator IdleTime()
		{
			yield return new WaitForSeconds(Random.Range(MinIdleTime, MaxIdleTime));
			state = State.StartPatrolling;
		}
	}
