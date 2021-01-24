C#
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityStandardAssets.Characters.FirstPerson;
// I AM USING THE PATHFOLLOWER SCRIPT FROM PATHCREATOR UNITY ASSET (modified to my will) 
//		All function besides what's inside the void update and void onPathchange functions have been made manually
// Put this script on the FPScontroller
// Specify the pathCreator (object created with a unity assets and that is basicaly a draw line using bezieLine in the environnement that objects can follow)
// Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
public class Follower : MonoBehaviour
{
	public PathCreator pathCreator; // Object PathCreator to put specify in Unity (gameObject with specifics scripts)
	public EndOfPathInstruction instructionFinChemin; // Variable that ask if the FPScontroller needs to stop/loop/reverse at the end of the path
	[Range(1, 10)]
	public float speedOfPlayer = 5; // Speed of the FPScontroller
	float distanceTravelled; // Used to calculate the distance the FPS will need to walk
	// Variable used to count time in secondes
	private int timer = 0;
	// Used for spawning items (itemFixe) in a specific location (spawnPoint) using randomization
	// 3 listes de gameObject (items fixe, mobile ou mixte) associés à 3 listes de trandform (spawnPoint fixe, mobile, mixte)
	[SerializeField]
	public GameObject[] itemFixe;
	public GameObject[] itemMobile;
	public GameObject[] itemMixte;
	
	public Transform[] spawnPoint;
	public Transform[] spawnPointMobile;
	public Transform[] spawnPointMixte;
	// Variables for the Spawn function : 
	//		indexPosition used to check the spawnPoint[indexPosition] transform
	//		indexItem used to check the item[indexItemn] gameObject
	//		compteur used to check 'if' condition
	private int indexPositionFixe = 0;
	private int indexPositionMobile = 0;
	private int indexPositionMixte = 0;
	private int compteurFixe = 0;
	private int compteurMobile = 0;
	private int compteurMixte = 0;
	private int indexItemFixe = 0;
	private int indexItemMobile = 0;
	private int indexItemMixte = 0;
	void Start()
	{
		// Used to count time and trigger stops
		StartCoroutine(DelayLoadLevel());
		// To assure RigidBodyFPSController Script will not interfer with PathCreator Script
		GameObject.Find("RigidBodyFPSController").GetComponent<RigidbodyFirstPersonController>().enabled = false;
		// Randomize prefabs using the RandomizeArray function
		RandomizeArray<GameObject>(itemFixe);
		RandomizeArray<GameObject>(itemMobile);
		RandomizeArray<GameObject>(itemMixte);
		// Linked to the pathUpdated event : notified if the path changes during the game
		if (pathCreator != null)
		{
			pathCreator.pathUpdated += OnPathChanged;
		}
	}
	void Update()
	{
		if (pathCreator != null & (timer % 4 != 0))
		{
			
			distanceTravelled += speedOfPlayer * Time.deltaTime;
			// Movement along the path
			transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, instructionFinChemin);
			// Rotation along the path
			transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, instructionFinChemin);
		}
	}
	
	// Fonction Coroutine to count time and stop RigidBodyFPSController for 4 secondes
	IEnumerator DelayLoadLevel()
	{
		while (true)
		{
			yield return new WaitForSeconds(1);
			timer = timer + 1;
			print("timer = " + timer);
			if (pathCreator != null && timer % 4 == 0)
			{
				Debug.Log("Enter IF timer == 4 secondes");
				Spawn();
				yield return new WaitForSeconds(4);
			}
		}
	}
	//public static void RemoveAt(ref T[] array, int index);
	void Spawn()
	{
		Debug.Log("Enter Spawn function");
		if (compteurFixe < itemFixe.Length)
		{
			Debug.Log("Boucle ITEM FIXE ");
			Debug.Log("indexArrayItemFixe " + indexItemFixe);
			Debug.Log("indexPositionItemFixe " + indexPositionFixe);
			Debug.Log("compteur de la boucle IF " + compteurFixe);
			Destroy(Instantiate(itemFixe[indexItemFixe], spawnPoint[indexPositionFixe].position, spawnPoint[indexPositionFixe].rotation), 4);
			Debug.Log("Item spawned : " + compteurFixe);
			indexItemFixe++;
			indexPositionFixe++;
			compteurFixe++;
		}
		else if (compteurMobile < itemMobile.Length && compteurFixe >= itemFixe.Length)
		{
			Debug.Log("Boucle ITEM MOBILE ");
			Debug.Log("indexArrayItemMobile " + indexItemMobile);
			Debug.Log("indexPositionItemMobile " + indexPositionMobile);
			Debug.Log("compteur de la boucle IF " + compteurMobile);
			Destroy(Instantiate(itemMobile[indexItemMobile], spawnPointMobile[indexPositionMobile].position, spawnPointMobile[indexPositionMobile].rotation), 4);
			Debug.Log("Item spawned : " + compteurMobile);
			indexItemMobile++;
			indexPositionMobile++;
			compteurMobile++;
		}
		else if (compteurMixte < itemMixte.Length && compteurFixe >= itemFixe.Length && compteurMobile >= itemMobile.Length)
		{
			Debug.Log("Boucle ITEM MIXTE");
			Debug.Log("indexArrayItemMixte " + indexItemMixte);
			Debug.Log("indexPositionItemMixte " + indexPositionMixte);
			Debug.Log("compteur de la boucle IF " + compteurMixte);
			Destroy(Instantiate(itemMixte[indexItemMixte], spawnPointMixte[indexPositionMixte].position, spawnPointMixte[indexPositionMixte].rotation), 4);
			Debug.Log("Item spawned : " + compteurMixte);
			indexItemMixte++;
			indexPositionMixte++;
			compteurMixte++;
		}
		else { print("No More Item"); }
	}
	//Function to randomize array's of gameObject
	public static void RandomizeArray<T>(T[] array)
	{
		int size = array.Length; // initialize Size used in the for function
		for (int z = 0; z < size; z++)
		{
			int indexToSwap = Random.Range(z, size);
			T swapValue = array[z];
			array[z] = array[indexToSwap];
			array[indexToSwap] = swapValue;
		}
	}
// If the path changes during the game, update the distance travelled so that the follower's position on the new path
// is as close as possible to its position on the old path
void OnPathChanged()
	{
		distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
	}
	//End of Script
}
