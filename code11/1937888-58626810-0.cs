    using System;
    using Android.Content;
    using Android.Views;
    using Android.Widget;
    using BumpTech.GlideLib;
    using Java.Lang;
    using Smarteist.AutoImageSlider;
    
    namespace testproject.Droid
    {
        public class testclass :  SliderViewAdapter
        {
            private Context context;
            public testclass(Context context)
            {
                this.context = context;
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
                imageViewBackground = itemView.FindViewById(Resource.Id.iv_auto_image_slider);
                textViewDescription = itemView.FindViewById(Resource.Id.tv_auto_image_slider);
                this.itemView = itemView;
            }
        }
    }
    }
