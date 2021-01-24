    using System.Collections;
    using System.Threading.Tasks;
    using UnityEngine;
    
    public class TestCoroutines : MonoBehaviour
    {
    	void Start () => D();
    	IEnumerator A () { yield return new WaitForSeconds(1f); print($"A completed in {Time.time}s"); }
    	IEnumerator B () { yield return new WaitForSeconds(2f); print($"B completed in {Time.time}s"); }
    	IEnumerator C () { yield return new WaitForSeconds(3f); print($"C completed in {Time.time}s"); }
    	async void D ()
    	{
    		Task a = Task.Run( async ()=> await A() );
    		Task b = Task.Run( async ()=> await B() );
    		Task c = Task.Run( async ()=> await C() );
    		await Task.WhenAll( a , b , c );
    		print($"D completed in {Time.time}s");
    	}
    }
