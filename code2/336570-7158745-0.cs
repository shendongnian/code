	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Linq;
	using System.Text;
	using System.Windows.Forms;
		// this is internal to the project namespace, say, TimsWorld_o_Hurt
		// I'm now resisting calling everything Xxxx_o_Hurt :)
		// examples o' hurt
	using EventHandlingLibrary;
	namespace EventHandlingLibrary
	{
		// this will provide the base class for all the events, and can
		// also have static methods like factory methods, destination 
		// lookups etc. 
		// I have the enums set to protected with the intent being that
		// specific factory functions should be called by other classes.
		// You should change this if it turns out to be too cumbersome.
		public class EventOfHurt
		{
			#region Event Definitions
				protected enum EEventType
				{
					// System Events
					SystemInitializing,
					SubsystemInitComplete,
					FatalErrorNotification,
					SubsystemPingReponse,
					SubsystemPingRequest,
					// Network Events
					FrameRateError,
					ThroughputData,
					ServerTimeout,
					ServerPingRequest,
					ServerPingResponse,
					// User Events
					WeaponsFire,
					MovementNotification,
					FatigueUpdate
					// and so forth
				}
				protected enum ESubsystem
				{
					System,
					Dispatcher,
					TickerTimer,
					WorldEntity,
					WorldTaskManager,
					UserMessageProcessor,
					NetworkListener,
					NetworkTransmitter,
					ProtocolEncoder,
					ProtocolDecoder,
					PlayerCharacter,
					NonPlayerCharacter,
					EventSink,
					EventSource
					// and such
				}
			#endregion
			#region Event Information
				public Guid EventId { get; protected set; }
				public EEventType EventType { get; protected set; }
				public ESubsystem SourceSubsystem { get; protected set; }
				public ESubsystem DestSubsystem { get; protected set; }
				private List<Tuple<EventOfHurt, DateTime>> 
					myEventReferences;
				// the event(s) that triggered it, if any, and when rec'd
				public Tuple<EventOfHurt, DateTime>[] 
					EventReferences 
				{ 
					get { return myEventReferences.ToArray(); } 
				}
				public DateTime Timestamp { get; private set; }
			#endregion
			// we'll be using factor methods to create events
			// so keep constructors private; no default constructor
			private EventOfHurt(
				EEventType evt,
				ESubsystem src, 
				ESubsystem dest = ESubsystem.Dispatcher
			)
			{
				EventType = evt;
				SourceSubsystem = src;
				DestSubsystem =  dest;
				EventId = Guid.NewGuid();
				Timestamp = DateTime.UtcNow;
			}
	
			// called to create a non-derived event for simple things; 
			// but keep other classes limited to calling specific factory
			// methods
			protected static EventOfHurt CreateGeneric(
				EEventType evt, ESubsystem src, 
				ESubsystem dest = ESubsystem.Dispatcher,
				Tuple<EventOfHurt, DateTime>[] reasons = null
			)
			{
				EventOfHurt RetVal;
				if (dest == null)
					dest = ESubsystem.Dispatcher;
				List<Tuple<EventOfHurt, DateTime>> ReasonList = 
					new List<Tuple<EventOfHurt,DateTime>>();
				if (reasons != null)
					ReasonList.AddRange(reasons);
				// the initializer after the constructor allows for a 
				// lot more flexibility than e.g., optional params
				RetVal = new EventOfHurt(evt, src) {
					myEventReferences = ReasonList
				};
				return RetVal;
			}
			// some of the specific methods can just return a generic
			// non-derived event
			public static EventOfHurt CreateTickerTimerEvent(
				EEventType evt, ESubsystem dest
			)
			{
				ESubsystem src = ESubsystem.TickerTimer;
				return CreateGeneric(evt, src, dest, null);
			}
			// some may return actual derived classes
			public static EventOfHurt CreatePlayerActionEvent(
				EEventType evt, ESubsystem dest,
				Tuple<EventOfHurt, DateTime>[] reasons
			)
			{
				PlayerEvent PE = new PlayerActionEvent(42);
				return PE;
			}
		}
		// could have some specific info relevant to player 
		// events in this class, world location, etc.
		public class PlayerEvent :
			EventOfHurt
		{
		};
		// and even further speciailzation here, weapon used
		// speed, etc. 
		public class PlayerActionEvent :
			PlayerEvent
		{
			public PlayerActionEvent(int ExtraInfo)
			{
			}
		};
	}
	namespace EntitiesOfHurt
	{
		public class LatchedBool
		{
			private bool myValue = false;
			public bool Value
			{
				get { return myValue; }
				set {
					if (!myValue)
						myValue = value;
				}
			}
		}
		public class EventOfHurtArgs :
			EventArgs
		{
			public EventOfHurtArgs(EventOfHurt evt)
			{
				myDispatchedEvent = evt;
			}
			private EventOfHurt myDispatchedEvent;
			public EventOfHurt DispatchedEvent
			{
				get { return myDispatchedEvent; }
			}
		}
		public class MultiDispatchEventArgs :
			EventOfHurtArgs
		{
			public MultiDispatchEventArgs(EventOfHurt evt) :
				base(evt)
			{
			}
			public LatchedBool isHandled; 
		}
		public interface IEventSink
		{
			// could do this via methods like this, or by attching to the
			// events in a source
			void MultiDispatchRecieve(object sender, MultiDispatchEventArgs e);
			void EventOfHurt(object sender, EventOfHurtArgs e);
			// to allow attaching an event source and notifying that
			// the events need to be hooked
			void AttachEventSource(IEventSource evtSource);
			void DetachEventSource(IEventSource evtSource);
		}
		// you could hook things up in your app so that most requests
		// go through the Dispatcher
		public interface IEventSource
		{
			// for IEventSinks to map
			event EventHandler<MultiDispatchEventArgs> onMultiDispatchEvent;
			event EventHandler<EventOfHurtArgs> onEventOfHurt;
			void FireEventOfHurt(EventOfHurt newEvent);
			void FireMultiDispatchEvent(EventOfHurt newEvent);
			// to allow attaching an event source and notifying that
			// the events need to be hooked
			void AttachEventSink(IEventSink evtSink);
			void DetachEventSink(IEventSink evtSink);
		}
		// to the extent that it works with your model, I think it likely
		// that you'll want to keep the event flow being mainly just
		// Dispatcher <---> Others and to minimize except where absolutely
		// necessary (e.g., performance) Others <---> Others.
		// DON'T FORGET THREAD SAFETY! :)
		public class Dispatcher : 
			IEventSource, IEventSink
		{
		}
		public class ProtocolDecoder :
			IEventSource
		{
		}
		public class ProtocolEncoder :
			IEventSink
		{
		}
		public class NetworkListener
		{
			// just have these as members, then you can have the
			// functionality of both on the listener, but the 
			// listener will not send or receive events, it will
			// focus on the sockets.
			private ProtocolEncoder myEncoder;
			private ProtocolDecoder myDecoder;
		}
		public class TheWorld :
			IEventSink, IEventSource
		{
		}
		public class Character
		{
		}
		public class NonPlayerCharacter :
			Character,
			IEventSource, IEventSink
		{
		}
		public class PlayerCharacter :
			Character,
			IEventSource, IEventSink
		{
		}
	}
    
 
