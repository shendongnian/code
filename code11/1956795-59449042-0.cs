c#
using System.Collections.Generic;
using UnityEngine;
public class Boid : MonoBehaviour
{
	private List<Transform> context = new List<Transform>();
	private void OnTriggerEnter(Collider other)
	{
		// good if you want to call the other Boid component
		Boid boid = other.gameObject.GetComponent<Boid>();
		if (boid != null)
		{
			context.Add(other.transform);
		}
	}
	private void OnTriggerExit(Collider other)
	{
		// Pretty efficient, requires tagging of boid objects
		if (other.CompareTag("boidTag"))
		{
			context.Remove(other.transform);
		}
	}
	private void Update()
	{
		foreach(Transform otherBoid in context)
		{
			// doing some stuff here based on boids within context
		}
	}
}
