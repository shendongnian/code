    public class LerpExample : MonoBehaviour
    {
        public Color[] skyColors = new Color[3];
        // added this just to see the result also in the inspector
        public Color currentAmbientcolor;
        public enum WeatherType
        {
            ClearSky,
            Clouds,
            RainStorm
        }
        public WeatherType currentWeather;
        // how long should lerping take
        // I find that easier to configure than using
        // speed - if you don't like it you can use timePassed += Tie.deltaTime * speed again
        public float LerpDuration = 1.0f;
        public Material rainMat;
        public bool isLerpingWeather;
        public bool isLerpingRain;
        // You can store those already in the beginning
        // makes it a bit better performance
        private Color rainFaidedOut;
        private Color rainFaidedIn;
        private void Awake()
        {
            rainFaidedOut = new Color(rainMat.color.r, rainMat.color.g, rainMat.color.b, 0);
            rainFaidedIn = new Color(rainMat.color.r, rainMat.color.g, rainMat.color.b, 1);
        }
        private IEnumerator CycleWeather()
        {
            if (isLerpingWeather) yield break;
            isLerpingWeather = true;
            // get target color
            var currentIndex = (int)currentWeather;
            var newIndex = (currentIndex + 1) % skyColors.Length;
            var targetColor = skyColors[newIndex];
            currentWeather = (WeatherType)newIndex;
            // Here I just guessed you want that the rainMat is already
            // set to invisible when the weather has changed
            // except for RainStorm
            if (currentWeather != WeatherType.RainStorm) rainMat.color = rainFaidedOut;
            // get current color
            var currentColor = RenderSettings.ambientSkyColor;
            var timePassed = 0f;
            do
            {
                RenderSettings.ambientSkyColor = Color.Lerp(currentColor, targetColor, timePassed / LerpDuration);
                // added this just to see it in the inspector
                currentAmbientcolor = RenderSettings.ambientSkyColor;
                timePassed += Time.deltaTime;
                yield return null;
            } while (timePassed < LerpDuration);
            // just to be sure there is no over/under shooting set the target value in the end
            RenderSettings.ambientSkyColor = targetColor;
            // added this just to see it in the inspector
            currentAmbientcolor = RenderSettings.ambientSkyColor;
            isLerpingWeather = false;
            // after the currentWeather has changed start the LerpingRain routine
            // for the two cases where you want it
            // since you already have set the RenderSettings.ambientSkyColor = targetColor;
            // there is reason to do so every frame again
            if (currentWeather != WeatherType.RainStorm) StartCoroutine(LerpingRain());
        }
        private IEnumerator LerpingRain()
        {
            // skip if already lerping rain to avoid parallel routines
            if (isLerpingRain) yield break;
            // also skip if currently lerping wheather to avoid parallel routines
            if (isLerpingWeather) yield break;
            // set flag to be sure no other routine will be running
            isLerpingRain = true;
            var timePassed = 0f;
            do
            {
                rainMat.color = Color.Lerp(rainFaidedOut, rainFaidedIn, timePassed / LerpDuration);
                timePassed += Time.deltaTime;
                yield return null;
            } while (timePassed < LerpDuration);
            rainMat.color = rainFaidedIn;
            isLerpingRain = false;
        }
        // Now only used to get the input
        private void Update()
        {
            // You want GetKeyDown here to execute this only once instead of every frame!
            if (Input.GetKey("space") && !isLerpingWeather)
            {
                print("changing weather");
                // Interrupt current routines
                StopAllCoroutines();
                StartCoroutine(CycleWeather());
            }
        }
    }
    
