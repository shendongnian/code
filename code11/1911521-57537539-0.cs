c#
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
public class MidiDriverDemo : MonoBehaviour
{
    public static readonly float CYCLE_TIME_SEC = 1f;
    private float remainingTime;
    private Dictionary<int, byte[]> messages;
    private int currentMessage;
    [DllImport("midi")]
    private static extern float midi_init();
    [DllImport("midi")]
    private static extern float midi_shutdown();
    [DllImport("midi")]
    private static extern float midi_write(byte[] msg, int length);
        
    // Start is called before the first frame update
    void Start()
    {
        remainingTime = CYCLE_TIME_SEC;
        currentMessage = 0;
        messages = new Dictionary<int, byte[]>() {
            {  0, new byte[] { 0x90, 48, 100 } },
            {  1, new byte[] { 0x80, 48, 0 } }
        };
        midi_init();
    }
    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;
        if(remainingTime <= 0) {
            remainingTime = CYCLE_TIME_SEC;
            midi_write(messages[currentMessage], 3);
            currentMessage++;
            currentMessage %= messages.Count;
        }
    }
}
There is finally audio output on the device.
