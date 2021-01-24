<android.widget.RelativeLayout 
    xmlns:android="http://schemas.android.com/apk/res/android"
    xmlns:app="http://schemas.android.com/apk/res-auto"
    xmlns:tools="http://schemas.android.com/tools"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    tools:context=".MyActivity"
    android:id="@+id/my_activity">
        <LinearLayout
            android:layout_width="match_parent"
            android:layout_height="match_parent"
            android:orientation="horizontal">
            <com.smarteist.autoimageslider.SliderView
                android:id="@+id/imageSlider1"
                android:layout_width="0dip"
                android:layout_height="match_parent"
                app:sliderAnimationDuration="600"
                app:sliderAutoCycleDirection="back_and_forth"
                app:sliderAutoCycleEnabled="true"
                app:sliderCircularHandlerEnabled="true"
                app:sliderIndicatorAnimationDuration="600"
                app:sliderIndicatorGravity="center_horizontal|bottom"
                app:sliderIndicatorMargin="15dp"
                app:sliderIndicatorOrientation="horizontal"
                app:sliderIndicatorPadding="3dp"
                app:sliderIndicatorRadius="2dp"
                app:sliderIndicatorSelectedColor="#5A5A5A"
                app:sliderIndicatorUnselectedColor="#FFF"
                app:sliderScrollTimeInSec="1"
                app:sliderStartAutoCycle="true"
                android:layout_weight=".5"/>
        </LinearLayout>
</android.widget.RelativeLayout>
**SliderAdapterExample Class:**
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Smarteist.AutoImageSlider;
using BumpTech.GlideLib;
namespace MyApp
{
    public class SliderAdapterExample : SliderViewAdapter
    {
        private Context context;
        private int mCount;
        public SliderAdapterExample(Context context)
        {
            this.context = context;
        }
        public void setCount(int count)
        {
            this.mCount = count;
        }
        public int getCount()
        {
            //slider view count could be dynamic size
            return mCount;
        }
        public override int Count => 4;
        public override void OnBindViewHolder(Java.Lang.Object viewHolder, int position)
        {
            SliderAdapterVH _viewHolder = (SliderAdapterVH)viewHolder;
            _viewHolder.textViewDescription.Text = "This is slider item " + position;
            switch (position)
            {
                case 0:
                    Glide.With(_viewHolder.itemView)
                            .Load("https://images.pexels.com/photos/218983/pexels-photo-218983.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260")
                            .Into(_viewHolder.imageViewBackground);
                    break;
                case 1:
                    Glide.With(_viewHolder.itemView)
                            .Load("https://images.pexels.com/photos/747964/pexels-photo-747964.jpeg?auto=compress&cs=tinysrgb&h=750&w=1260")
                            .Into(_viewHolder.imageViewBackground);
                    break;
                case 2:
                    Glide.With(_viewHolder.itemView)
                            .Load("https://images.pexels.com/photos/929778/pexels-photo-929778.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260")
                            .Into(_viewHolder.imageViewBackground);
                    break;
                default:
                    Glide.With(_viewHolder.itemView)
                            .Load("https://images.pexels.com/photos/218983/pexels-photo-218983.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260")
                            .Into(_viewHolder.imageViewBackground);
                    break;
            }
        }
        public override Java.Lang.Object OnCreateViewHolder(ViewGroup parent)
        {
            View inflate = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.image_slider_layout_item, null);
            return new SliderAdapterVH(inflate);
        }
        class SliderAdapterVH : SliderViewAdapter.ViewHolder
        {
            public View itemView;
            public ImageView imageViewBackground;
            public TextView textViewDescription;
            public SliderAdapterVH(View itemView) : base(itemView)
            {
                
                imageViewBackground = itemView.FindViewById<ImageView>(Resource.Id.iv_auto_image_slider);
                textViewDescription = itemView.FindViewById<TextView>(Resource.Id.tv_auto_image_slider);
                this.itemView = itemView;
            }
        }
    }
}
MyActivity:
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Android.App;
using Android.OS;
using Android.Widget;
using Smarteist.AutoImageSlider;
namespace MyApp
{
    [Activity(Label = "MyActivity", MainLauncher = true)]
    public class MyActivity: Activity
    {
        SliderView sliderView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.my_activity);
            sliderView = FindViewById<SliderView>(Resource.Id.imageSlider1);
            SliderAdapterExample adapter = new SliderAdapterExample(this);
            adapter.setCount(25);
            sliderView.SliderAdapter = adapter;
            sliderView.SetIndicatorAnimation(IndicatorAnimations.Slide); //set indicator animation by using SliderLayout.IndicatorAnimations. :WORM or THIN_WORM or COLOR or DROP or FILL or NONE or SCALE or SCALE_DOWN or SLIDE and SWAP!!
            sliderView.SetSliderTransformAnimation(SliderAnimations.CubeInRotationTransformation);
            sliderView.AutoCycleDirection =SliderView.AutoCycleDirectionBackAndForth;
            sliderView.IndicatorSelectedColor = Android.Graphics.Color.White;
            sliderView.IndicatorUnselectedColor = Android.Graphics.Color.Gray;
            sliderView.ScrollTimeInSec=4;
            //sliderView.AutoCycleDirection = SliderAnimations.CubeInRotationTransformation;
            sliderView.StartAutoCycle();
        }
    }
}
